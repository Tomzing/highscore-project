import { useEffect, useState } from 'react';
import './HighscoreList.css'

const HighscoreList = ({ gameId }) => {
    const [scores, setScores] = useState([]);
    const [games, setGames] = useState([]);
    const [error, setError] = useState([]);

    /*const highscoreList = async () => {
        const response = await axios.get(`http://localhost:5193/api/scores${gameId}`)
        .then(response => response.json());
    }*/

    useEffect(() => {
        fetch(`http://localhost:5193/api/scores?gameId=${gameId}`)
        .then(response => response.json())
        .then(res => setScores(res))
        .catch(err => console.log(err))
    }, []);

    

    /*useEffect(() => {
        const fetchScores = async () => {
            const response = await axios.get(`/api/scores?${gameId}`);
            setScores(response.data);
        };
        fetchScores();
    }, [gameId]);*/

    return (
        <div>
        <div className="main-content ">
            <div className="main-content__header">
            <h1 className="logo-1">Kvikna</h1>
            <h2 className="glow-blue">Hall of Fame 🚀</h2>
            </div>

            <div className="game-selection">
            <p>Spillnavn 🐍</p>
            </div>

            <div className="border floating">
            <div className="main-content__table">
                <table>
                <thead>
                    <tr>
                        <th>Score</th>
                        <th>Navn</th>
                        <th>Email</th>
                    </tr>
                </thead>
                {scores.map(score => 
                    <tbody key={scores.id}>
                        <td>{score.points}</td>      
                        <td>{score.playerName}</td>
                        <td>{score.email}</td>
                    </tbody>
                )}
                </table>
            </div>
            </div>
        </div>
    </div>

    );
};

export default HighscoreList;