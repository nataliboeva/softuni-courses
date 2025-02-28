function calculate(fruit, grams, pricePerKilo){
    let kilo = grams / 1000;
    console.log(`I need $${(kilo * pricePerKilo).toFixed(2)} to buy ${kilo.toFixed(2)} kilograms ${fruit}.`);
}

calculate('orange', 2500, 1.80);
calculate('apple', 1563, 2.35);