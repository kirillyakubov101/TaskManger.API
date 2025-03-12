using Application.Tasks.Commands.CreateTask;
using AutoMapper;
using Domain.Entities.Task;
using SharedModels;

namespace Application.Tasks.Dtos;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskCommand, UserTask>()
            .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(d => d.DueDate, opt => opt.MapFrom(src => src.DueDate));

        CreateMap<UserTask, UserTaskDto>();
    }
}
