using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Models
{
    public interface IFormFile
    {
        //
        // Summary:
        //     Gets the raw Content-Type header of the uploaded file.
        string ContentType { get; }

        //
        // Summary:
        //     Gets the raw Content-Disposition header of the uploaded file.
        string ContentDisposition { get; }

        //
        // Summary:
        //     Gets the file length in bytes.
        long Length { get; }

        //
        // Summary:
        //     Gets the form field name from the Content-Disposition header.
        string Name { get; }

        //
        // Summary:
        //     Gets the file name from the Content-Disposition header.
        string FileName { get; }

        //
        // Summary:
        //     Opens the request stream for reading the uploaded file.
        Stream OpenReadStream();

        //
        // Summary:
        //     Copies the contents of the uploaded file to the target stream.
        //
        // Parameters:
        //   target:
        //     The stream to copy the file contents to.
        void CopyTo(Stream target);

        //
        // Summary:
        //     Asynchronously copies the contents of the uploaded file to the target stream.
        //
        //
        // Parameters:
        //   target:
        //     The stream to copy the file contents to.
        //
        //   cancellationToken:
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken));
    }
}
