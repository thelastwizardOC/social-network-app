import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

<<<<<<< HEAD
platformBrowserDynamic()
  .bootstrapModule(AppModule)
=======
platformBrowserDynamic().bootstrapModule(AppModule)
>>>>>>> ee12fbc (feat: create get photos api + photo tab UI)
  .catch(err => console.error(err));
