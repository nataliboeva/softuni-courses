function solve(input){
    let evenSum = 0;
    let oddSum = 0;

    for(let i = 0; i <= input.length - 1; i++){
        if(input[i] % 2 == 0){
            evenSum += input[i];
        }
        else{
            oddSum += input[i];
        }
    }
    console.log(evenSum - oddSum);
}
solve([1,2,3,4,5,6]);
solve([3,5,7,9]);
solve([2,4,6,8,10]);