import { useEffect, useState } from 'react';

const PickGameList = () => {
    const [games, setGames] = useState([]);
    const [error, setError] = useState([]);

    /*const highscoreList = async () => {
        const response = await axios.get(`http://localhost:5193/api/scores${gameId}`)
        .then(response => response.json());
    }*/

    useEffect(() => {
        fetch(`http://localhost:5193/api/games}`)
        .then(response => response.json())
        .then(res => setGames(res))
        .catch(err => console.log(err))
    }, []);


    return (
        <div>
            <h2>Pick a game</h2>
            <ul>
                {games.map(game => (
                    <li key={game.id}>{game.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default PickGameList;