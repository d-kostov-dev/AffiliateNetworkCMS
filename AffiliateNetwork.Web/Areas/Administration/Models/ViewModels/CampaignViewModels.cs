﻿namespace AffiliateNetwork.Web.Areas.Administration.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;

    using AutoMapper;
    
    public class ListCampaignsViewModel : IMapFrom<Campaign>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Type")]
        public virtual CampaignType Type { get; set; }

        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        public decimal Payout { get; set; }

        [Display(Name = "Owner")]
        public virtual User Owner { get; set; }

        [Display(Name = "Affiliates")]
        public int AffiliatesCount { get; set; }

        [Display(Name = "Expires")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Clicks")]
        public int ClicksCount;

        [Display(Name = "Conversions")]
        public int ConversionsCount;

        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Campaign, ListCampaignsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name.ToString()))
                .ForMember(m => m.AffiliatesCount, opt => opt.MapFrom(u => u.Affiliates.Count))
                .ForMember(m => m.ClicksCount, opt => opt.MapFrom(u => u.Clicks.Count))
                .ForMember(m => m.ConversionsCount, opt => opt.MapFrom(u => u.Conversions.Count));
        }
    }

    public class ListCampaignsDetailsViewModel : IMapFrom<Campaign>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Type")]
        public virtual CampaignType Type { get; set; }

        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        public decimal Payout { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Expires")]
        public DateTime ValidTo { get; set; }

        [Display(Name = "Clicks")]
        public ICollection<Click> Clicks;

        [Display(Name = "Conversions")]
        public ICollection<Conversion> Conversions;

        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        public string OwnerId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Campaign, ListCampaignsDetailsViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name.ToString()))
                .ForMember(m => m.CompanyName, opt => opt.MapFrom(u => u.Owner.CompanyName));
        }
    }
}