using AutoMapper.Configuration.Annotations;
using BankManagementSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace BankManagementSystem.CQRS.Commands;

public class UpdateClientCommand : IRequest<(bool, string)>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
