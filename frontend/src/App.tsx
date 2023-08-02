import { useMemo, useState } from 'react'
import './App.css';
import Field from './components/Field'
import CalculatorService from './services/CalculatorService'
import Validator from './services/Validator'
import InvalidInputError from './errors/InvalidInputError'
import CalculatorResult from './models/CalculatorResult'

function App() {
  let [a, setA] = useState("")
  let [b, setB] = useState("")
  let [expr, setExpr] = useState("")
  let [result, setResult] = useState("")
  let [error, setError] = useState("")

  const calculatorService = useMemo(() => new CalculatorService(), [])

  const handleResult = async (func: () => Promise<CalculatorResult>) => {
    try {
      setResult((await func()).result)
      setError("")
    }
    catch (error) {
      if (error instanceof InvalidInputError)
        setError(error.message)
      
      else 
        setError("Processing error")
    }
  }

  const handleSimpleChange = (setState: (state: string) => void) => {
    return (event: React.ChangeEvent<HTMLInputElement>) => {
      if (Validator.isValidSimpleInput(event.target.value)) {
        setState(event.target.value);
      }
    }
  }

  const handleExpressionChange = (setState: (state: string) => void) => {
    return (event: React.ChangeEvent<HTMLInputElement>) => {
      if (Validator.isValidExpression(event.target.value)) {
        setState(event.target.value);
      }
    }
  }

  return (
    <div className="App">
      <div className='title'>
        <h1>Calculator</h1>
      </div>
      <main className='main'> 
        <div className='actions'>
          <div className='operations'>
            <Field title='a'
              state={a}
              handleChange={handleSimpleChange(setA)}
            />
            <Field title='b'
              state={b}
              handleChange={handleSimpleChange(setB)}
            />
            <div className='buttons'>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.add(a, b))}
              >
                +
              </button>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.sub(a, b))}
              >
                -
              </button>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.mul(a, b))}
              >
                *
              </button>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.div(a, b))}
              >
                /
              </button>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.pow(a, b))}
              >
                pow
              </button>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.root(a, b))}
              >
                root
              </button>
            </div>

          </div>
          <div className='operations'>
            <Field title='expression'
              state={expr}
              handleChange={handleExpressionChange(setExpr)}
            />
            <div className='buttons'>
              <button className='button'
                onClick={() => handleResult(() => calculatorService.expr(expr))}
              >
                Calc
              </button>
            </div>
          </div>
        </div>
        {
          result &&
          <div className='result'> Result: {result}</div>
        }
        {
          error && 
          <div className='error'> Error: {error} </div>
        }
      </main>
    </div>
  );
}

export default App;
