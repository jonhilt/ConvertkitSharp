using Machine.Specifications;
using ConvertKitSharp.Services;
using ConvertKitSharp.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ConvertKitSharp.Tests.Tags
{
    [Subject(typeof(ConvertKitTagService))]
    class When_listing_tags
    {
        Establish context = () =>
        {
            Service = new ConvertKitTagService(Utils.ApiKey);
        };

        Because of = () =>
        {
            Result = Service.ListAsync().Await().AsTask.Result;
        };

        It should_list_tags = () =>
        {
            Result.ShouldNotBeNull();
            
            if(Result.Count() > 0)
            {
                var result = Result.First();
                
                result.Id.ShouldNotBeNull();
                result.Id.ShouldBeGreaterThan(0);
                result.Name.ShouldNotBeNull();
                result.CreatedAt.ShouldNotBeNull();
                result.CreatedAt.ShouldBeGreaterThan(new DateTime());
            }
        };

        Cleanup after = () =>
        {

        };

        static ConvertKitTagService Service;

        static IEnumerable<ConvertKitTag> Result;
    }
}
