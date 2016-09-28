using AutoMapper;
using MidiaSocialEmpresa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AtividadeViewModel, Atividade>();
            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<ProfissionalViewModel, Profissional>();
            Mapper.CreateMap<ProjetoViewModel, Projeto>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}