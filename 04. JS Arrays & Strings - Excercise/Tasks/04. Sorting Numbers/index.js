function solve(numbers){
    let newArr = [];
    numbers.sort((a,b) => a - b);
    let index = 0;

    for(let i = 0; i < numbers.length; i++){
        newArr[index++] = numbers[i];
        if(index == numbers.length) break;
        newArr[index++] = numbers[numbers.length - 1 - i];
        if(index == numbers.length) break;
    }
    return newArr;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);