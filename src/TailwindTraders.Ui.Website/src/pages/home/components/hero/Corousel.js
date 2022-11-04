import React from 'react';
import Carousel from 'react-material-ui-carousel'
import { Paper, Button, Grid } from '@material-ui/core'
import LocalMallIcon from '@material-ui/icons/LocalMall';
export default function Corousel(props)
{
    var items = [
        {
            name: "The Fastest, Most Powerful Xbox Ever.",
            description: "Elevate your game with the all-new Xbox Wireless Controller - Lunar Shift Special Edition"
        },
    ]

    return (
        <Carousel
            indicatorContainerProps={{
                style: {
                    zIndex:'1',
                    display: 'flex',
                    position:'absolute',
                    justifyContent:'center',
                    bottom:'20px'
                }
        
            }}
            >
            {
                items.map( (item, i) => <Item key={i} item={item} /> )
            }
        </Carousel>
    )
}

function Item(props)
{
    return (
        <div className="courousel-style">
            <Grid container spacing={3}>
                <Grid item xs={5} className="BannerGrid">
                    <div className="BannerHeading">
                        {props.item.name}
                    </div>
                    <div className="BannerContent">
                        {props.item.description}
                    </div>
                    <div className="BannerButtondiv">
                        <Button
                            aria-controls="customized-menu"
                            aria-haspopup="true"
                            variant="contained"
                            color="primary"
                            className="box-shadow-0 text-transform-capitalize fw-regular BannerButton1"
                            endIcon={<LocalMallIcon />}
                            size="large"
                        >
                            Buy Now
                        </Button>
                        <Button
                            aria-controls="customized-menu"
                            aria-haspopup="true"
                            variant="contained"
                            color="default"
                            className="box-shadow-0 text-transform-capitalize fw-regular BannerButton2"
                            size="large"
                        >
                            More Details
                        </Button>
                    </div>
                </Grid>
                <Grid item xs={7}>
                </Grid>
            </Grid>
        </div>
    )
}