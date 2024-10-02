using CardsService.Sdk.Exceptions;
using CardsService.Sdk.Extensions;
using CardsService.Sdk.Grpc;
using CardsService.Sdk.Interceptors.Helpers;
using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Threading.Tasks;

namespace CardsService.Sdk.Interceptors
{
    public class DomainExceptionInterceptor : Interceptor
    {
        #region client

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var call = continuation(request, context);

            return new AsyncUnaryCall<TResponse>(
                HandleResponse(call.ResponseAsync),
                call.ResponseHeadersAsync,
                call.GetStatus,
                call.GetTrailers,
                call.Dispose);
        }

        private async Task<TResponse> HandleResponse<TResponse>(Task<TResponse> inner)
        {
            try
            {
                return await inner;
            }
            catch (RpcException ex)
            {
                if (ex.Trailers.TryGetErrorCode(MetadataHeaders.ErrorCodeHeader, out var errorCode))
                {
                    throw new ServiceException(errorCode);
                }
                throw new InvalidOperationException(ex.Message, ex);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        #endregion

        #region server

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                throw AdaptException(ex);
            }
        }

        private RpcException AdaptException(Exception ex)
        {
            var metadata = new Metadata();
            if (ex is ServiceException serviceException)
            {
                metadata.Add(MetadataHeaders.ErrorCodeHeader, serviceException.ErrorCode);
            }
            var status = GetStatusByException(ex);
            return new RpcException(status, metadata);
        }
        private Status GetStatusByException(Exception ex)
        {
            switch (ex)
            {
                case ServiceException serviceException: return new Status(serviceException.ErrorCode.ConvertToStatusCode(), serviceException.Message);
                default: return new Status(StatusCode.Internal, ex.Message);
            };
        }

        #endregion
    }
}
