using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events;

public class OrderProcessed
{
    public required string OrderId { get; init; }
}