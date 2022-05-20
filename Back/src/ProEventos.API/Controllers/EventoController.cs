﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular 11 e .NET 5 ",
                    Local = "Belo Horizonte",
                    Lote = "1° Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImagemUrl = "foto.png"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Angular e testes ",
                    Local = "Rio de Janeiro",
                    Lote = "2° Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(4).ToString(),
                    ImagemUrl = "foto.png"
                },
        };

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(x => x.EventoId == id); 
        }
    }
}

