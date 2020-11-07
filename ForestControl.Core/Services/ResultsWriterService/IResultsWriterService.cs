using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Services
{
    public interface IResultsWriterService
    {
        Task WriteAResult(ExecutionResult executionResult);
    }
}
