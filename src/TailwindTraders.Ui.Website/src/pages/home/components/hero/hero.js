import React, { Component } from "react";

import { NamespacesConsumer } from "react-i18next";

import { ReactComponent as Freeshipping } from "../../../../assets/images/icon-freeshipping.svg";
import Herobg from "../../../../assets/images/herobg.jpg";
import Corousel from "./Corousel";
class Hero extends Component {
    constructor(props) {
        super(props);
        this.bgImg = React.createRef();
    }

    render() {
        return (
            <NamespacesConsumer>
                {t => (
                    <div className="hero">
                        <Corousel />
                    </div>
                )}
            </NamespacesConsumer>
        );
    }
}

export default Hero;
