function solve(word, text){
    if(text.toLocaleLowerCase().split(' ').includes(word.toLocaleLowerCase())){
        console.log(word);
    }
    else{
        console.log(`${word} not found!`)
    }
}

solve('javascript','JavaScript is the best programming language');
solve('python', 'JavaScript is the best programming language');