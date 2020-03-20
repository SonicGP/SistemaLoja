using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaLoja.Models;

namespace SistemaLoja.Controllers
{
    public class FuncionarioController : Controller
    {
        private SistemaLojaContext db = new SistemaLojaContext();

        // GET: Funcionario
        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.TipoDocumento);
            return View(funcionarios.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            var list = db.TipoDocumentoes.ToList();
            list.Add(new TipoDocumento { TipoDocumentoId = 0, Descricao = "[Selecione um tipo de documento!]" });
            list = list.OrderBy(c => c.Descricao).ToList();
            ViewBag.TipoDocumentoId = new SelectList(list, "TipoDocumentoId", "Descricao");
            //ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "TipoDocumentoId", "Descricao");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuncionarioId,Nome,Sobrenome,Salario,Comissao,Nascimento,Cadastro,Email,TipoDocumentoId")] Funcionario funcionario)
        {
            var TipoDocumentoId = int.Parse(Request["TipoDocumentoId"]);
            if (TipoDocumentoId == 0)
            {
                var list = db.TipoDocumentoes.ToList();
                list.Add(new TipoDocumento { TipoDocumentoId = 0, Descricao = "[Selecione um tipo de documento!]" });
                list = list.OrderBy(c => c.Descricao).ToList();
                ViewBag.TipoDocumentoId = new SelectList(list, "TipoDocumentoId", "Descricao");
                ViewBag.Error = "Selecione um Documento";

                return View();
            }
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "TipoDocumentoId", "Descricao", funcionario.TipoDocumentoId);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "TipoDocumentoId", "Descricao", funcionario.TipoDocumentoId);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuncionarioId,Nome,Sobrenome,Salario,Comissao,Nascimento,Cadastro,Email,TipoDocumentoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumentoes, "TipoDocumentoId", "Descricao", funcionario.TipoDocumentoId);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
