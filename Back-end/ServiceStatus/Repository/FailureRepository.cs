using System;
using System.Collections.Generic;
using ServiceStatus.Model;

namespace ServiceStatus.Repository
{
    public interface FailureRepository
    {
        Failure Create(Failure failure);    //Criar uma falha com um determinado ID
        Failure FindById(long id);          //Encontrar por ID da falha criada por ID
        List<Failure> FindAll();            //Encontrar todos
        Failure Update(Failure failure);    //Update da falha 
        void Delete(long id);               //Apagar a falha
    }
}
