using Api_curso.HiperMidia.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_curso.HiperMidia {
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHiperMedia {
       
        public bool CanEnrich(Type contextType) {
            return contextType == typeof(T) || contextType == typeof(List<T>);
        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response) {
            if (response.Result is OkObjectResult okobjectResult) {
                return CanEnrich(okobjectResult.Value.GetType());
            }
            return false;
        }

        public async Task Enrich(ResultExecutingContext response) {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
           
            if 
                (response.Result is OkObjectResult okobjectResult) {
                if (okobjectResult.Value is T model) {
                    await EnrichModel(model, urlHelper);
                
                } else if(okobjectResult.Value is List<T> collection) {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) => {
                        EnrichModel(element, urlHelper);
                    });
                }
                await Task.FromResult<Object>(null);
            }
        }
    }
}
