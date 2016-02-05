let sub x xbar = x - xbar

let multi x y = x * y

#r "../packages/MathNet.Numerics.3.10.0/lib/net40/MathNet.Numerics.dll"
#r "../packages/MathNet.Numerics.FSharp.3.10.0/lib/net40/MathNet.Numerics.FSharp.dll"

open MathNet.Numerics

let (xdata:double array) = [|10.0;20.0;30.0|]
let (ydata:double array) = [|15.0;20.0;25.0|]

let intercept, slope = Fit.Line (xdata, ydata)
//xdata.Select(x => a+b*x)
GoodnessOfFit.RSquared((Array.map (fun x -> intercept + slope * x) xdata) , ydata); //1.0 is perfect
