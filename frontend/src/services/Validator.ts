const simpleRegex = /^\d+$/;
const expressionRegex = /[^0-9-+*\/^\(\) ]/;

const Validator = {
    isValidSimpleInput: (input: string) => 
        input === "" || simpleRegex.test(input),
    
    isValidExpression: (input: string) =>
        input === "" || !expressionRegex.test(input)
}

export default Validator