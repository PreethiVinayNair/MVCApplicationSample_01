import React, { Component } from 'react';
import AppActions from './../actions/AppActions';
import { get, post } from "../lib/http";


export class PostNameData extends Component {
  static displayName = PostNameData.name;

  constructor(props) {
    super(props);
    PostNameData.update();
  }

  save() {
    post('api/postnamedata', datacollection, (content) => {
      NotificationManager.success('Name added');
      history.push(`/postnamedata/${content.id}`);
    });
  }




  render() {
    const { datacollection } = this.props;


    return (
      <div>
        <div>
          <h1>Name Addition</h1>
          <Form horizontal>
            <FormGroup controlId="FirstName">
              <Col componentClass={ControlLabel} sm={2} >
                FirstName
                        </Col>
              <Col sm={10}>
                <FormControl type="text" value={datacollection.firstname}
                  onChange={bindValueTo('datacollection.firstname')} />
              </Col>
            </FormGroup>
            <FormGroup controlId="LastName">
              <Col componentClass={ControlLabel} sm={2}>
                LastName
                        </Col>
              <Col sm={10}>
                <FormControl type="number" value={datacollection.lastname}
                  onChange={bindValueTo('datacollection.lastname')} />
              </Col>
            </FormGroup>
            </Form>
        </div>
      </div>

    );
  }

}

PostNameData.defaultProps = {
  loading: false,
  datacollection: []
}