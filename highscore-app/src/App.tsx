import { useState } from 'react'
import './App.css'
import HighscoreList from './HighscoreList'
import PickGameList from './PickGameList'


function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <PickGameList />
      <HighscoreList gameId={1}/>
    </>
  )
}

export default App
