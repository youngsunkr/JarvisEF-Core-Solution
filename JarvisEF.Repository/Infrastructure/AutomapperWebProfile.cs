using JarvisEF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JarvisEF.Repository.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {

            //CreateMap<EmployeeDomainModel, EmployeeViewModel>();

            //CreateMap<EmployeeViewModel, EmployeeDomainModel>();

            CreateMap<EmployeeDomainModelWeb, EmployeeViewModel>()

                .ForMember(dest => dest.ExtraValue, opt => opt.MapFrom(src => src.ExtraValue.Encrypt()))
                .ForMember(dest => dest.CurrentDate, opt => opt.MapFrom(src => src.CurrentDate.ToString("MM/dd/yyy hh:mm")));
            CreateMap<EmployeeDomainModelWeb, EmployeeViewModel>();

            //Reverese mapping

            CreateMap<EmployeeViewModel, EmployeeDomainModel>();
            CreateMap<EmployeeDomainModel, EmployeeViewModel>();

        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();


            });
        }
    }

    public static class ExtensionMethod
    {

        public static string Encrypt(this Int32 num)
        {

            return "Technotips:" + num;
        }
    }
}