﻿using AutoMapper;
using FreeCourse.Services.Order.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.Address, AddressDTO>().ReverseMap();
        }
    }
}
