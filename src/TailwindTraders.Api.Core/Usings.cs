﻿global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Logging;
global using Microsoft.ML.OnnxRuntime;
global using Microsoft.ML.OnnxRuntime.Tensors;
global using SixLabors.ImageSharp;
global using SixLabors.ImageSharp.Processing;
global using TailwindTraders.Api.Core;
global using TailwindTraders.Api.Core.Constants;
global using TailwindTraders.Api.Core.Exceptions;
global using TailwindTraders.Api.Core.Models;
global using TailwindTraders.Api.Core.Models.Implementations.Dao;
global using TailwindTraders.Api.Core.Models.Implementations.Dto;
global using TailwindTraders.Api.Core.Models.Interfaces;
global using TailwindTraders.Api.Core.Repositories;
global using TailwindTraders.Api.Core.Repositories.Implementations;
global using TailwindTraders.Api.Core.Repositories.Interfaces;
global using TailwindTraders.Api.Core.Requests.Definitions;
global using TailwindTraders.Api.Core.Requests.Validators;
global using TailwindTraders.Api.Core.Services.Implementations;
global using TailwindTraders.Api.Core.Services.Interfaces;



