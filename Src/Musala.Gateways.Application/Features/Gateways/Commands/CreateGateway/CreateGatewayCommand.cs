﻿
using MediatR;
using Musala.Gateways.Application.Features.Devices.Queries.GetAllDevices;
using Musala.Gateways.Application.Features.Gateways.Queries.GetAllGateways;
using System.Collections.Generic;

namespace Musala.Gateways.Application.Features.Gateways.Commands.CreateGateway
{
    public class CreateGatewayCommand : IRequest<GatewayDto>
    {
        public string Name { set; get; }
        public string SerialNumber { set; get; }
        public string IpV4Address { set; get; }
        public List<DeviceDto> Devices { get; set; }
    }
}
