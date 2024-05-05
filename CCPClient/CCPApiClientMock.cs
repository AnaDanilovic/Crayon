using CloudSales.Model.Model;

namespace CCPClient
{
    public class CCPApiClientMock : ICCPApiClient
    {
        public Task<List<Software>> GetServicesAsync()
        {
            var services =  new List<Software>
            {
                //office
                new Software {
                SoftwareId= 1,
                SoftwareName = "Microsoft Office"
                },
                new Software {
                SoftwareId= 2,
                SoftwareName = "Google Workspace"
                },
                new Software {
                SoftwareId= 3,
                SoftwareName = "Apache OpenOffice"
                },
                new Software {
                SoftwareId= 4,
                SoftwareName = "LibreOffice"
                },
                new Software {
                SoftwareId= 5,
                SoftwareName = "WPS Office"
                },
                //design
                new Software {
                SoftwareId= 6,
                SoftwareName = "Adobe Photoshop"
                },
                new Software {
                SoftwareId= 7,
                SoftwareName = "Adobe Illustrator"
                },
                new Software {
                SoftwareId= 8,
                SoftwareName = "Sketch"
                },
                new Software {
                SoftwareId= 9,
                SoftwareName = "CorelDRAW"
                },
                new Software {
                SoftwareId= 10,
                SoftwareName = "Autodesk AutoCAD"
                },
                //AI
                new Software {
                SoftwareId= 11,
                SoftwareName = "TensorFlow"
                },
                new Software {
                SoftwareId= 12,
                SoftwareName = "PyTorch"
                },
                new Software {
                SoftwareId= 13,
                SoftwareName = "IBM Watson"
                },
                new Software {
                SoftwareId= 14,
                SoftwareName = "Microsoft Azure AI"
                },
                new Software {
                SoftwareId= 15,
                SoftwareName = "OpenAI GPT (Generative Pre-trained Transformer)"
                }
            };

            return Task.FromResult(services);
        }
    }
}
