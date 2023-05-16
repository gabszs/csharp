using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaDominio.Entidade
{
    public class Produto
    {
        public Guid id { get; set; }

        public string Nome { get; set; }
        
        public int Quantidade { get; set; }
        
        public decimal Valor { get; set; }
        
        public DateTime DataVencimento { get; set; }

        private List<Produto> _produtos;

        public Produto()
        {
            _produtos = new List<Produto>();
        }

        public List<Produto> ListarFrutas ()
        {
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Banana", Quantidade = 2, Valor = 3, DataVencimento = DateTime.Now.AddDays(5)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Manga", Quantidade = 3, Valor = 4, DataVencimento = DateTime.Now.AddDays(6)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "MAmao", Quantidade = 4, Valor = 5, DataVencimento = DateTime.Now.AddDays(7)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "limao", Quantidade = 5, Valor = 10, DataVencimento = DateTime.Now.AddDays(8)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "tomate", Quantidade = 6, Valor = 52, DataVencimento = DateTime.Now.AddDays(5)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Melancia", Quantidade = 7, Valor = 15, DataVencimento = DateTime.Now.AddDays(10)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "pao frances", Quantidade = 8, Valor = 72, DataVencimento = DateTime.Now.AddDays(2)});
            return _produtos;
        }
        public List<Produto> ListarLegumes ()
        {
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "alfece", Quantidade = 2, Valor = 3, DataVencimento = DateTime.Now.AddDays(5)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Rucula", Quantidade = 3, Valor = 4, DataVencimento = DateTime.Now.AddDays(6)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "pepino", Quantidade = 4, Valor = 5, DataVencimento = DateTime.Now.AddDays(7)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Alcatra", Quantidade = 5, Valor = 10, DataVencimento = DateTime.Now.AddDays(8)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Picanha", Quantidade = 6, Valor = 52, DataVencimento = DateTime.Now.AddDays(5)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Fraldinha", Quantidade = 7, Valor = 15, DataVencimento = DateTime.Now.AddDays(10)});
            _produtos.Add(new Produto() { id = Guid.NewGuid(), Nome = "Pork Ribs", Quantidade = 8, Valor = 72, DataVencimento = DateTime.Now.AddDays(2)});
            return _produtos;
        }

    }
}
