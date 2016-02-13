using Machine.Specifications;
using ConvertKitSharp.Services;
using ConvertKitSharp.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ConvertKitSharp.Tests.Courses
{
    [Subject(typeof(ConvertKitCourseService))]
    class When_listing_courses
    {
        Establish context = () =>
        {
            Service = new ConvertKitCourseService(Utils.ApiKey);
        };

        Because of = () =>
        {
            Result = Service.ListAsync().Await().AsTask.Result;
        };

        It should_list_courses = () =>
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

        static ConvertKitCourseService Service;

        static IEnumerable<ConvertKitCourse> Result;
    }
}
