using AutoMapper;
using InDev.Models;
using InDev.DbModels;

namespace InDev.Configuration
{
    internal class ApiMapperConfigurator
    {
        private readonly IMapperConfigurationExpression _expression;

        public IMapperConfigurationExpression AddConfiguration() => _expression;

        public ApiMapperConfigurator(IMapperConfigurationExpression expression)
        {
            MappingApiToDo(expression);

            _expression = expression;
        }

        private void MappingApiToDo(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ApiToDo, DalToDo>().ReverseMap();
        }
    }
}
