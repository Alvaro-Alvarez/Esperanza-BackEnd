﻿namespace Esperanza.Core.Models.Request
{
    public class Filter : Pagination
    {
        public string? Search { get; set; }
        public bool? WithSemaphore { get; set; }
        public List<string>? Marcas { get; set; }
        public List<string>? Proveedores { get; set; }
        public List<string>? Subrubros { get; set; }
        public List<string>? Vademecums { get; set; }
        public List<string>? Tipos { get; set; }
        public List<string>? Laboratorios { get; set; }
        public List<string>? Categorias { get; set; }
        public List<string>? Drogas { get; set; }
        public List<string>? Acciones { get; set; }
        public List<string>? Especies { get; set; }
        public List<string>? ViaAdministraciones { get; set; }
        public List<string>? Condiciones { get; set; }

        public Filter()
        {
            //Marcas = new List<string>();
            //Proveedores = new List<string>();
            //Subrubros = new List<string>();
            //Vademecums = new List<string>();
            //Tipos = new List<string>();
            //Laboratorios = new List<string>();
            //Categorias = new List<string>();
            //Drogas = new List<string>();
            //Acciones = new List<string>();
            //Especies = new List<string>();
            //ViaAdministraciones = new List<string>();
            Condiciones = new List<string>();
        }
    }
}
