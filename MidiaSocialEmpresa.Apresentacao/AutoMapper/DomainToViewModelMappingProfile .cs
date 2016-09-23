using AutoMapper;
using MidiaSocialEmpresa.Dominio.Entidades;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile

    {
        protected override void Configure()
        {
            Mapper.CreateMap<Atividade, AtividadeViewModel>();
            Mapper.CreateMap<Empresa, EmpresaViewModel>();
            Mapper.CreateMap<Profissional, ProfissionalViewModel>();
            Mapper.CreateMap<Projeto, ProjetoViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}