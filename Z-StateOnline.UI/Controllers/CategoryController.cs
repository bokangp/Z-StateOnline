﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Z_StateOnline.Core.Contracts;
using Z_StateOnline.Core.Models;
using Z_StateOnline.DataAccess.Inmemory;

namespace Z_StateOnline.UI.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<ProductCategory> context;
        public CategoryController(IRepository<ProductCategory> categoryContext)
        {
            context = categoryContext;
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCategory> categories = context.Collection().ToList();
            return View(categories);
        }
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productcategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productcategory);
            }
            else
            {
                context.Insert(productcategory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory CategoryToEdit = context.Find(Id);
            if (CategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                CategoryToEdit.Category = productCategory.Category;
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(CategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}