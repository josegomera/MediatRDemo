using DemoLib.Commads;
using DemoLib.DataAccess;
using DemoLib.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLib.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InserPersonCommand, PersonModel>
    {
        private readonly IDataAccess _dataAccess;

        public InsertPersonHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<PersonModel> Handle(InserPersonCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.InsertPeople(request.FirtName, request.LastName));
        }
    }
}
