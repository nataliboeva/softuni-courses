function solve(names){
    names.sort((a,b) => a.localeCompare(b))
    .map((name, index) => {
        console.log(`${index + 1}.${name}`)
    });
}

solve(['John', 'Bob', 'Christina', 'Ema']);