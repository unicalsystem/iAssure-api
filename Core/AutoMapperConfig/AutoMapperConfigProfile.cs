using AutoMapper;
using backend_dotnet.Core.Dtos.Location;
using backend_dotnet.Core.Dtos.Measure;
using backend_dotnet.Core.Dtos.MeasureGroup;
using backend_dotnet.Core.Dtos.Standard;
using backend_dotnet.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace backend_dotnet.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            //Standard
            CreateMap<StandardCreateDto, Standard>();
            CreateMap<Standard, StandardGetDto>();

            //MeasureGroup 
            CreateMap<MeasureGroupCreateDto, MeasureGroup>();
            CreateMap<MeasureGroup, MeasureGroupGetDto>()
                     .ForMember(dest => dest.StandardName, opt => opt.MapFrom(src => src.Standard.Name));

                // Measure
                CreateMap<MeasureCreateDto, Measure>();
                CreateMap<Measure, MeasureGetDto>()
                    .ForMember(dest => dest.MeasureGroupName, opt => opt.MapFrom(src => src.MeasureGroup.MeasureName));

            // HeadOffice
            CreateMap<HeadOfficeCreateDto, HeadOffice>();
            CreateMap<HeadOffice, HeadOfficeGetDto>();
            CreateMap<HeadOfficeUpdateDto, HeadOffice>();

            // Branch
            CreateMap<BranchCreateDto, Branch>();
            CreateMap<Branch, BranchGetDto>()
                 .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.HeadOffice.Location));
            CreateMap<BranchUpdateDto, Branch>();
        }
    }
    }

