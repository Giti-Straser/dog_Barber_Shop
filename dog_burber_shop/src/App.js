//import logo from './logo.svg';
import './App.css';
import Login from './comps/Login';
import db from './connectToDB'
import { Route, Routes, Switch } from 'react-router-dom'
import Queue from './comps/Queue';
import SignIn from './comps/SignIn';
import UpdateQueue from './comps/UpdateQueue';
import AddQueue from './comps/AddQueue';

function App() {

  
  return (
    <div className="App">
      <h1 className='title'>Dog burber shop</h1>
      <Routes>
        <Route path='/' element={<Login />}/>
        <Route path='/signIn' element={<SignIn />}/>
        <Route path='/queue' element={<Queue />} />
        <Route path='/queue/updateQueue' element={<UpdateQueue />} />
        <Route path='/queue/addQueue' element={<AddQueue />} />
      </Routes>
    </div>
  );
}

export default App;
