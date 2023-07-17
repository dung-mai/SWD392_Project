﻿using SWD392_PracinicalManagement.IRepository;
using SWD392_PracinicalManagement.IService;
using SWD392_PracinicalManagement.Models;
using SWD392_PracinicalManagement.Repository;

namespace SWD392_PracinicalManagement.Service
{
    public class ExaminationFormService : IExaminationFormService
    {
        IExaminationFormRepository repo = new ExaminationFormRepository();
        public List<ExaminationForm> GetExaminationForms()
        {
            return repo.GetExaminationForms();
        }
    }
}
