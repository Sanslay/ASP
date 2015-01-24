using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pam.Metier.Entites
{
  // classe d'exception
  public class PamException : Exception
  {
    // le code de l'erreur
    public int Code { get; set; }
    // constructeurs
    public PamException()
    {
    }
    public PamException(int Code)
      : base()
    {
      this.Code = Code;
    }
    public PamException(string message, int Code)
      : base(message)
    {
      this.Code = Code;
    }
    public PamException(string message, Exception ex, int Code)
      : base(message, ex)
    {
      this.Code = Code;
    }
  }
}