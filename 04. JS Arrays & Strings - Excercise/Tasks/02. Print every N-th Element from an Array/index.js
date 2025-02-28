function solve(array, count){
    let arrayTemp = [];
    for(let i = 0; i < array.length; i++){
        if(i % count == 0){
            arrayTemp.push(array[i]);
        }
    }
    return arrayTemp;
}
solve(['5','20', '31', '4', '20'], 2);