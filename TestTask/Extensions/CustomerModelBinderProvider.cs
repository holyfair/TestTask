using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Enums;
using TestTask.Models.Customer;

namespace TestTask.JsonConverters
{
    public class CustomerModelBinderProvider : IModelBinderProvider
    {
        private readonly IList<IInputFormatter> formatters;
        private readonly ILoggerFactory loggerFactory;
        private readonly MvcOptions options;
        private readonly IHttpRequestStreamReaderFactory readerFactory;

        public CustomerModelBinderProvider(
            IList<IInputFormatter> formatters,
            IHttpRequestStreamReaderFactory readerFactory,
            ILoggerFactory loggerFactory,
            MvcOptions options)
        {
            this.formatters = formatters;
            this.readerFactory = readerFactory;
            this.loggerFactory = loggerFactory;
            this.options = options;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.BindingInfo.BindingSource != null &&
                context.BindingInfo.BindingSource.CanAcceptDataFrom(BindingSource.Body) &&
                context.Metadata.ModelType == typeof(CustomerBase))
            {
                if (this.formatters.Count == 0)
                {
                    throw new InvalidOperationException("this.formatters.Count == 0");
                }

                var subclasses = new[] { typeof(MrGreenCustomer), typeof(RedBetCustomer), };

                var metadatas = new Dictionary<Type, ModelMetadata>();
                foreach (var type in subclasses)
                {
                    var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                    metadatas[type] = modelMetadata;
                }

                return new CustomerModelBinder(this.formatters, this.readerFactory, this.loggerFactory, this.options, metadatas);
            }

            return null;
        }

        public class CustomerModelBinder : IModelBinder
        {
            private readonly IList<IInputFormatter> formatters;
            private readonly ILoggerFactory loggerFactory;
            private readonly Dictionary<Type, ModelMetadata> metadatas;
            private readonly MvcOptions options;
            private readonly IHttpRequestStreamReaderFactory readerFactory;

            public CustomerModelBinder(
                IList<IInputFormatter> formatters,
                IHttpRequestStreamReaderFactory readerFactory,
                ILoggerFactory loggerFactory,
                MvcOptions options,
                Dictionary<Type, ModelMetadata> metadatas)
            {
                this.formatters = formatters;
                this.readerFactory = readerFactory;
                this.loggerFactory = loggerFactory;
                this.options = options;
                this.metadatas = metadatas;
            }

            public async Task BindModelAsync(ModelBindingContext bindingContext)
            {
                var modelBrandType = ModelNames.CreatePropertyModelName(bindingContext.ModelName, "BrandType");
                var modelTypeValue = bindingContext.ValueProvider.GetValue(modelBrandType).FirstValue;

                ModelMetadata modelMetadata;
                Enum.TryParse(modelTypeValue, out BrandType brandType);
                if (brandType == BrandType.MrGreen)
                {
                    modelMetadata = metadatas[typeof(MrGreenCustomer)];
                }
                else if (brandType == BrandType.RedBet)
                {
                    modelMetadata = metadatas[typeof(RedBetCustomer)];
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Failed();
                    return;
                }

                var innerModelBinder = new BodyModelBinder(this.formatters, this.readerFactory, this.loggerFactory, this.options);

                bindingContext.ModelMetadata = modelMetadata;
                await innerModelBinder.BindModelAsync(bindingContext);
            }
        }
    }
}