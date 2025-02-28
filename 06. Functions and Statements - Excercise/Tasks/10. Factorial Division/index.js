function factorial (num1, num2){
    const factorialCalculate = (num) => {
        if(num == 0 || num == 1) return 1;
        else return num * factorialCalculate(num - 1);
    }

    const num1Factorial = factorialCalculate(num1);
    const num2Factorial = factorialCalculate(num2);
    const result = (num1Factorial / num2Factorial).toFixed(2);
    console.log(result);
}
factorial(5,2);