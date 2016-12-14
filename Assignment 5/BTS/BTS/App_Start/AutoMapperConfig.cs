//
// author: Mona and Jagmeet
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace BTS
{
	public static class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			// Add map creation statements here
			// Mapper.CreateMap< FROM , TO >();

			// Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

			// AutoMapper create map statements

			Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

            Mapper.CreateMap<Models.Incident, Controllers.IncidentBase>();
            Mapper.CreateMap<Models.Incident, Controllers.IncidentWithDetails>();
            Mapper.CreateMap<Models.Incident, Controllers.IncidentEdit>();
            Mapper.CreateMap<Models.Incident, Controllers.IncidentEditForm>();
            Mapper.CreateMap<Controllers.IncidentBase, Controllers.IncidentEditForm>();
            Mapper.CreateMap<Controllers.IncidentEditForm, Controllers.IncidentEdit>();
            Mapper.CreateMap<Controllers.IncidentEdit, Controllers.IncidentEditForm>();

            Mapper.CreateMap<Models.Instructor, Controllers.InstructorBase>();

            Mapper.CreateMap<Models.Student, Controllers.StudentBase>();
            Mapper.CreateMap<Models.Student, Controllers.StudentWithDetails>();

            // Add more below...





#pragma warning restore CS0618
        }
	}
}