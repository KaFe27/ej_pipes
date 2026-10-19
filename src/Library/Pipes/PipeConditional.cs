using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucu.Poo.PipesAndFilters;

namespace Ucu.Poo.PipesAndFilters.Pipes
{
    public class PipeConditional : IPipe
    {
        public IPipe NextPipeTrue{get; protected set;}
        public IPipe NextPipeFalse{get; protected set;}
        public IFilterConditional FilterConditional{get; protected set;}

        public PipeConditional (IFilterConditional filter,  IPipe nextPipeTrue, IPipe nextPipeFalse)
        {
            this.NextPipeTrue = nextPipeTrue;
            this.NextPipeFalse = nextPipeFalse;
            this.FilterConditional = filter;
        } 

        public IPicture Send(IPicture picture)
        {
            if (picture == null)
            {
                return null;
            }
            else if (this.FilterConditional.Filter(picture) == null)
            {
                return this.NextPipeFalse.Send(picture);
            }
            else
            {
                return this.NextPipeTrue.Send(picture);
            }
        }
        
    }
}