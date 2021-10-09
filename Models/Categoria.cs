using System;

namespace simple_todo_list.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}