function perform(number, op1, op2, op3, op4, op5){
    let numberTemp = number;

    for(let i = 1; i <= 5; i++){
        let currentOp = i === 1 ? op1 :
        i === 2 ? op2:
        i === 3 ? op3:
        i === 4 ? op4: op5;

        switch(currentOp){
            case 'chop':
                numberTemp /= 2;
                break;
            case 'dice':
                numberTemp = Math.sqrt(numberTemp);
                break;
            case 'spice':
                numberTemp++;
                break;
            case 'bake':
                numberTemp *= 3;
                break;
            case 'fillet':
                numberTemp = (numberTemp - (numberTemp * 0.2)).toFixed(1);
                break;
        }
        console.log(numberTemp);
    }
}
perform('32', 'chop', 'chop', 'chop', 'chop', 'chop');
perform('9', 'dice', 'spice', 'chop', 'bake', 'fillet');