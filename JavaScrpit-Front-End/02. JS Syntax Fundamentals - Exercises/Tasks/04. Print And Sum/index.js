function solve(start, end){
    let numbers = '';
    let sum = 0;
    for(let i = start; i <= end; i++){
        numbers += `${i} `;
        sum += i;
    }
    console.log(numbers);
    console.log(`Sum: ${sum}`);
}

solve(5,10);
solve(0,26);
solve(50,60);