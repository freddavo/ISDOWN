using System;
using System.Collections.Generic;
using ServiceStatus.Model;
using ServiceStatus.Repository;

namespace ServiceStatus.Service.Implementations
{
    public class FailureServiceImplementation : FailureService
    {
        private readonly Repository<Failure> _repository;

        public FailureServiceImplementation(Repository<Failure> repository)
        {
            _repository = repository;
        }

        public Failure Create(Failure failure)
        {
            return _repository.Create(failure);
        }

        public List<Failure> FindAll()
        {
            return _repository.FindAll();
        }

        public Failure FindById(long id)
        {
            return _repository.FindById(id);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
