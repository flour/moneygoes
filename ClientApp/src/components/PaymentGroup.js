import React, { Component } from 'react';
import * as axios from 'axios';

export class PaymentGroup extends Component {
    state = { name: '', description: '' }

    render() {
        return (
            <div>
                <h1>Login</h1>
                <form>
                    <input placeholder="E-mail" value={this.state.name} />
                    <br />
                    <input placeholder="Description" value={this.state.description} />
                    <br />
                    <button onClick={this.tryLogin} type="button">Save</button>
                </form>
            </div>
        );
    }
}