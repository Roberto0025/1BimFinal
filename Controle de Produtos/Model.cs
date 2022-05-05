using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_de_Produtos
{
    public class Model
    {
        internal void SetUsuario(DtoUsuario u)
        {
            Context context = new Context();
            context.usuario.Add(u);
            context.SaveChanges();
        }
        public List<DtoUsuario2> GetUsuarios()
        {
            Context db = new Context();

            List<DtoUsuario2> usuario = (from u in db.usuario
                                 select new DtoUsuario2
                                 {
                                     id = u.id,
                                     nome = u.nome
                                 }).ToList();
            return usuario;
        }
        public DtoUsuario GetUsuario(int id)
        {
            Context db = new Context();
            DtoUsuario user = db.usuario.FirstOrDefault(p => p.id == id);
            return user;
        }
        internal void AlterarUsuario(DtoUsuario u)
        {
            Context db = new Context();
            DtoUsuario user = db.usuario.FirstOrDefault(p => p.id == u.id);
            user.nome = u.nome;
            user.login = u.login;
            user.senha = u.senha;
            db.SaveChanges();
        }

        internal DtoProduto GetProdutoId(int v)
        {
            Context db = new Context();
            DtoProduto prod = db.produto.FirstOrDefault(p => p.id == v);
                if(prod != null)
            {
                return prod;
            }
            else
                return null;
        }

        internal void delUsuario(int id)
        {
            Context db = new Context();
            DtoUsuario user = db.usuario.FirstOrDefault(p => p.id == id);
            db.usuario.Remove(user);
            db.SaveChanges();
        }

        //===========================
        internal void SetProduto(DtoProduto p)
        {
            Context context = new Context();
            context.produto.Add(p);
            context.SaveChanges();
        }

        public List<DtoProduto2> GetProdutos()
        {
            Context db = new Context();

            List<DtoProduto2> prod = (from p in db.produto
                                     select new DtoProduto2
                                     {
                                         id = p.id,
                                         nome = p.nome,
                                         valorcompra = p.valorcompra,
                                         valorvenda = p.valorvenda,
                                         quantidade = p.quantidade,
                                         unidade = p.unidade
                                     }).ToList();
            return prod;
        }

        public DtoProduto GetProduto(int id)
        {
            Context db = new Context();
            DtoProduto prod = db.produto.FirstOrDefault(p => p.id == id);
            return prod;
        }
        internal void AlterarProduto(DtoProduto produto)
        {
            Context db = new Context();
            DtoProduto prod = db.produto.FirstOrDefault(p => p.id == produto.id);
            prod.nome = produto.nome;
            prod.valorvenda = produto.valorvenda;
            prod.valorcompra = produto.valorcompra;
            prod.quantidade = produto.quantidade;
            prod.unidade = produto.unidade;
            db.SaveChanges();
        }
        internal void delProduto(int id)
        {
            Context db = new Context();
            DtoProduto prod = db.produto.FirstOrDefault(p => p.id == id);
            db.produto.Remove(prod);
            db.SaveChanges();
        }

        //================================
        
        internal void SetEntradaProduto(DtoEntrada entrada)
        {
            Context db = new Context();
            var produto = db.produto.FirstOrDefault(p => p.id == entrada.idproduto);
            produto.quantidade = produto.quantidade + entrada.qtdeproduto;
            produto.valorcompra= entrada.vlrcustoproduto;

            db.entrada.Add(entrada);
            db.SaveChanges();
        }

        internal void SetSaidaProduto(DtoEntrada saida)
        {
            Context db = new Context();
            var produto = db.produto.FirstOrDefault(p => p.id == saida.idproduto);
            if(saida.qtdeproduto <= produto.quantidade)
            {
                produto.quantidade = produto.quantidade - saida.qtdeproduto;
                produto.valorcompra = saida.vlrcustoproduto;

                db.entrada.Add(saida);
                db.SaveChanges();
            }
            else
            {
                return;
            }

        }

        //================================
        public List<DtoProduto2> ListProdutosNome(string text)
        {
            Context db = new Context();
            List<DtoProduto2> result = (from a in db.produto where a.nome.Contains(text) select new DtoProduto2
            {
                id = a.id,
                nome = a.nome,
                quantidade = a.quantidade
            }).ToList();

            return result;
        }
    }
}
