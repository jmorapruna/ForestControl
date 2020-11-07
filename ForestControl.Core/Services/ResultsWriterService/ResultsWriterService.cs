using ForestControl.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ForestControl.Core.Services
{
    public class ResultsWriterService : IResultsWriterService
    {
        private readonly StreamWriter _outputStreamWriter;

        public ResultsWriterService(StreamWriter outputStreamWriter)
        {
            _outputStreamWriter = outputStreamWriter;
        }

        public async Task WriteAResult(ExecutionResult executionResult)
        {
            string result = $"{executionResult.FinalPosition.X} {executionResult.FinalPosition.Y} {executionResult.FinalDirection.GetCode()}";

            await _outputStreamWriter.WriteLineAsync(result);
        }
    }
}
